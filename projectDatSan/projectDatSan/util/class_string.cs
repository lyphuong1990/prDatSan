using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

    public class class_string
    {
        public class_string()
        {
        }


        // chuỗi ngẫu nhiên
        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public string GetPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        /* Mã MD5
         ---------------------------------*/
        //vuvdh

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        /* Kiem tra chuoi phai la chuoi so ko
         * Chỉ tính số nguyên
         ---------------------------------*/
        public static bool IsNumberInt(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        /* Kiem tra chuoi phai la chuoi so ko
         * Tính cả số thực
         ---------------------------------*/
        public static bool IsNumberFloat(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        /*
         * --- Loại bỏ kí tự 
         */
        public static string Clear(string str)
        {
            string result = str.Trim();
            result = result.Replace("'", "\"");
            return result;
        }

        public static string clear_html(string str)
        {
            str = HttpUtility.HtmlEncode(str);
            return str;
        }

        /* SEND MAIL
         ------------------------------------------------------------*/
        public static void SendMail(string from, string password, string to, string title, string content)
        {
            //Tạo đối tượng chứng thực e-mail người gửi
            NetworkCredential myEmail = new NetworkCredential(from, password);
            // Chi ra giao thức SMTP (Simple Mail Transfer Protocol) gửi mail
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 580;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = myEmail;
            //Tạo đối tượng chứa địa chỉ người gửi và người nhận
            MailAddress fromAdd = new MailAddress(from);
            MailAddress toAdd = new MailAddress(to);
            //Tạo đối tượng chứa nội dung e-mail
            MailMessage message = new MailMessage(fromAdd, toAdd);
            //Chỉ ra thông số cho email
            message.IsBodyHtml = true;
            message.Subject = title;
            message.Body = content;
            message.Priority = MailPriority.High;
            //Gửi e-mail
            smtpClient.Send(message);
        }

        /* Kiem tra dinh dang email
         ----------------------------------------*/
        public static bool isEmail(string inputEmail)
        {
            if (inputEmail == null || inputEmail.Length == 0)
            {
                throw new ArgumentNullException("inputEmail");
            }

            const string expression = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            Regex regex = new Regex(expression);
            return regex.IsMatch(inputEmail);
        }

        /* Tìm kiếm
         ----------------------------------------*/
        public static string bgword(string key, string documents)
        {
            return documents.Replace(key, "<span class='word_search'>" + key + "</span>");
        }

        public static string TachChuoi(string Input, int Num)
        {
            string Output = string.Empty;
            int len = Input.Length;
            int n = (int)(len / Num);
            if (n > 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    Output += Input.Substring((i - 1) * Num, Num) + " ";
                }
                Output += Input.Substring(n * Num, len - n * Num);

            }
            else
            {
                Output = Input;
            }
            return Output;
        }
        /*
            // Trả về thứ
 
            public static string GetThu(string _thu){
                string vThu = "";
                string[] thuVN = new[] { "2", "3", "4", "5", "6", "7", "8" };
                string[] thuEN = new[]{Resource.THUHAI, Resource.THUBA, Resource.THUTU, Resource.THUNAM,Resource.THUSAU,Resource.THUBAY,Resource.CHUNHAT};
                for (int i=0; i<thuVN.Length; i++){
                    if (_thu.Equals(thuVN[i])){
                        vThu = thuEN[i];
                    }
                }
                return vThu;
            }

            // Trả về ngày
            public static string GetNgay(string _ngay){
                string vNgay = "";
                string[] ngayVN = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
                string[] ngayEN = new[] { Resource.NGAY1,  Resource.NGAY2,  Resource.NGAY3,  Resource.NGAY4,  Resource.NGAY5,  Resource.NGAY6,  Resource.NGAY7,  Resource.NGAY8,  Resource.NGAY9,  Resource.NGAY10, Resource.NGAY11, Resource.NGAY12, 
                                          Resource.NGAY13, Resource.NGAY14, Resource.NGAY15, Resource.NGAY16, Resource.NGAY17, Resource.NGAY18, Resource.NGAY19, Resource.NGAY20, Resource.NGAY21, Resource.NGAY22, Resource.NGAY23, 
                                          Resource.NGAY24, Resource.NGAY25, Resource.NGAY26, Resource.NGAY27, Resource.NGAY28, Resource.NGAY29, Resource.NGAY30, Resource.NGAY31 };
                for (int i = 0; i < ngayVN.Length; i++){
                    if (_ngay.Equals(ngayVN[i])){
                        vNgay = ngayEN[i];
                    }
                }
                return vNgay;
            }
            */
        // Ham viet hoa chu cai dau
        public static string ToFirstUpper(string _strInput)
        {
            string subStr = "";
            subStr = _strInput.Substring(0, 1).ToUpper() + _strInput.Substring(1, _strInput.Length - 1);
            return subStr;
        }
        public string BuffEncoder(string input)
        {
            byte[] buf = Encoding.ASCII.GetBytes(input);
            int l1 = buf.Length;
            int l2 = (int)l1 / 2;
            int l3 = (int)l2 / 2;
            int l4 = l1 - l2;
            for (int i = 0; i < l3; i++)
            {
                int bytevaule = Convert.ToInt32(buf.GetValue(i));
                buf.SetValue((byte)(Convert.ToInt32(buf.GetValue(l2 - 1 - i))), i);
                buf.SetValue((byte)bytevaule, l2 - 1 - i);
                bytevaule = Convert.ToInt32(buf.GetValue(i + l4));
                buf.SetValue((byte)(Convert.ToInt32(buf.GetValue(l1 - 1 - i))), l4 + i);
                buf.SetValue((byte)bytevaule, l1 - 1 - i);
            }
            for (int i = 0; i < l1; i++)
            {
                int bytevaule = 255 - Convert.ToInt32(buf.GetValue(i));
                buf.SetValue((byte)bytevaule, i);
            }
            string output = Convert.ToBase64String(buf);
            buf.Clone();
            return output;
        }
        //--------------------------------------------------------------------------------------------------

        //----Giải mã chuỗi--------------------------------------------------------------------------------
        public string BuffDecoder(string input)
        {
            try
            {
                byte[] buf = Convert.FromBase64String(input);
                int l1 = buf.Length;
                int l2 = (int)l1 / 2;
                int l3 = (int)l2 / 2;
                int l4 = l1 - l2;
                for (int i = 0; i < l1; i++)
                {
                    int bytevaule = 255 - Convert.ToInt32(buf.GetValue(i));
                    buf.SetValue((byte)bytevaule, i);
                }
                for (int i = 0; i < l3; i++)
                {
                    int bytevaule = Convert.ToInt32(buf.GetValue(i));
                    buf.SetValue((byte)(Convert.ToInt32(buf.GetValue(l2 - 1 - i))), i);
                    buf.SetValue((byte)bytevaule, l2 - 1 - i);
                    bytevaule = Convert.ToInt32(buf.GetValue(i + l4));
                    buf.SetValue((byte)(Convert.ToInt32(buf.GetValue(l1 - 1 - i))), l4 + i);
                    buf.SetValue((byte)bytevaule, l1 - 1 - i);
                }
                string report = Encoding.ASCII.GetString(buf);
                buf.Clone();
                return report;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public string ConvertToHtmlTag(string input)
        {
            string output = "";
            output = input.Replace("&lt;", "<");
            output = input.Replace("&gt;", ">");
            return output;
        }
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
        // decode base 64
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }

