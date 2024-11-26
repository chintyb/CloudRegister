namespace WindowsFormsApp1
{
    internal static class ConvertUtil
    {
        public static string NameBytesToString(byte[] name)
        {
            if (name.Length != 32) return string.Empty;
            string str = "";
            foreach (byte b in name)
            {
                str += (char)b;
            }
            string temp = str.TrimStart('0');
            temp = temp.Trim('\0');
            if(temp.Length == 0)    return string.Empty;
            //NanChang need char n
            if (temp[0] == 'n')
            {
                str = temp.Substring(0, 12);
            }
            //HuaRun is 12 bit
            else if (temp[0] == '6' && temp[1] == '8')
            {
                str = temp.Substring(0, 12);
            }
            //CNP is 16 bit
            else if (temp[0] == '1' && temp[1] == '5' && temp[2] == '6')
            {
                str = temp.Substring(0, 16);
            }
            //WL07 chint protocol
            else if (temp[0] == '7')
            {
                str = temp.Substring(0, 11);
                str = '0' + str;
            }
            //ChangShu protocol 297
            else if (temp[0] == '2' && temp[1] == '9' && temp[2] == '7')
            {
                str = temp.Substring(0, 14);
            }
            else
            {
                str = temp;
            }
            return str;
        }

        public static string IMEIBytesToString(byte[] name)
        {
            if (name.Length != 32) return string.Empty;
            string str = "";
            foreach (byte b in name)
            {
                str += (char)b;
            }
            string temp = str.TrimStart('\0');

            if (temp.Length > 15) temp = temp.Substring(0, 15);

            return temp;
        }

        public static string IMSIBytesToString(byte[] name)
        {
            if (name.Length != 32) return string.Empty;
            string str = "";
            foreach (byte b in name)
            {
                str += (char)b;
            }
            string temp = str.Trim('\0');
            if (temp.Length > 15) temp = temp.Substring(0, 15);

            return temp;
        }

        public static string ICCIDBytesToString(byte[] name)
        {
            if (name.Length != 25) return string.Empty;
            string str = "";
            foreach (byte b in name)
            {
                str += (char)b;
            }
            string temp = str.Trim('\0');

            if (temp.Length > 20) str = temp.Substring(0, 20);

            return temp;
        }
    }
}
