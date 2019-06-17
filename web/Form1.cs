using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;

//http://soznatik.ru/blog/obmen_dannymi_s_bitriks24_rest_api_iz_net_c/2017-05-17-5
//https://dev.1c-bitrix.ru/learning/course/index.php?COURSE_ID=99&LESSON_ID=2486&LESSON_PATH=8771.5380.5379.2486

namespace web
{
    public partial class Form1 : Form
    {

        private List<Company> Comp = new List<Company>();

        private const string BX_Portal = "https://its74.bitrix24.ru/";
        private const string BX_OAuthSite = "https://oauth.bitrix.info";

        private const string BX_ClientID = "local.5cf6a95826cc69.20624049";
        private const string BX_ClientSecret = "Y6z0ELd1ZI9xGbZqI39H1vGXFBWsRoykO0Rq6UtLcbPncAH8Cs";

        private string token = "";
        private string endPoint = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LogonData ld = GetAuthCode();

                if (!String.IsNullOrEmpty(ld.CodeOAuth))
                {
                    string Auth_URI = BX_OAuthSite + "/oauth/token" + "/?" + "grant_type=authorization_code" + "&" +
                    "client_id=" + BX_ClientID + "&" +
                    "client_secret=" + BX_ClientSecret + "&" +
                    "code=" + ld.CodeOAuth;

                    string tokens = GetAuthToken(Auth_URI, ld.CookieOAuth);

                    JsonLoadSettings jls = new JsonLoadSettings();
                    jls.LineInfoHandling = LineInfoHandling.Load;
                    JObject obj = JObject.Parse(tokens, jls);

                    token = obj["access_token"].Value<string>();
                    endPoint = obj["client_endpoint"].Value<string>();

                    // Console.WriteLine(obj);
                    GetData(0);

                    Console.WriteLine(new DateTime(obj["expires"].Value<long>()));
                }
                else
                {
                    throw new Exception("Code не получен!");
                }

                Console.WriteLine(ld.CodeOAuth);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private LogonData GetAuthCode()
        {
            string BX_URI = BX_Portal + "/oauth/authorize/?client_id=" + BX_ClientID;
            string username = "vkondra@gmail.com";
            string password = "123Mazay";

            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(BX_URI);
            req.CookieContainer = new CookieContainer();

            req.Headers.Add("Authorization", "Basic " + svcCredentials);
            req.AllowAutoRedirect = false;
            req.Method = "POST";

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            if (resp.StatusCode == HttpStatusCode.Found)
            {

                Uri loc = new Uri(resp.Headers["location"]);
                //Cookie cookie = new Cookie( resp.Headers["Set-Cookie"]);

                var locationParams = System.Web.HttpUtility.ParseQueryString(loc.Query);

                Console.WriteLine(resp.Cookies);
                string Cookie = resp.Headers["Set-Cookie"];

                string Code = locationParams["Code"];

                //  MessageBox.Show(loc.AbsoluteUri);

                resp.Close();  //Перейти на Using!!!
                LogonData ld = new LogonData { CodeOAuth = Code, CookieOAuth = Cookie };

                return ld;//resp.StatusCode.ToString();
            }
            else
            {
                resp.Close();
                return null;
            }
            //using (StreamReader str = new StreamReader(
            //    resp.GetResponseStream(), Encoding.UTF8))
            //{
            //    return str.ReadToEnd();
            //}
        }

        private string GetAuthToken(string oauthUri, string cookie)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(oauthUri);
            req.Method = "POST";
            //?? req.Headers["Cookie"] = cookie;

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Ошибка при получении токена");
            }
            else
            {
                Stream strm = resp.GetResponseStream();
                var strmReader = new StreamReader(strm);
                String result = strmReader.ReadToEnd();
                resp.Close();
                return result;
            }

        }


        private string GetData(int next)
        {
            //string url = endPoint + "methods?scope=&full=true&auth=" + token;
            //string url = endPoint + "user.current" + "?auth=" + token;
            //string url = endPoint + "lists.get?IBLOCK_TYPE_ID=lists" + "&auth=" + token;
            string url = endPoint + "crm.company.list?start=" + next + "&auth=" + token;

            //crm.company.list
            //user.current
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Ошибка в GetData");
            }
            else
            {
                Stream strm = resp.GetResponseStream();
                var strmReader = new StreamReader(strm);
                String json = strmReader.ReadToEnd();


                JObject obj = JObject.Parse(json);
               JToken[] arr = obj["result"].ToArray();
                foreach (JToken jt in arr)
                {
                     Comp.Add(new Company { ID=(int)jt["ID"], TITLE=jt["TITLE"].ToString() });
                }

                if (obj["next"] != null)
                {

                    int nxt = obj["next"].Value<int>();

                        GetData(nxt);
                    
                }else
                {
                    Console.WriteLine(Comp);
                    resp.Close();
                }

            }

            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
    }

    public class LogonData
    {
        public string CodeOAuth { get; set; }
        public string CookieOAuth { get; set; }
    }

    public class Company
    {
        public int ID { get; set; }
        public string TITLE { get; set; }
    }
}
