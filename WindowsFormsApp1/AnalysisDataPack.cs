using System;

namespace WindowsFormsApp1
{
    public class AnalysisDataPack
    {
        //data recived from port,for example 68 30 etc.
        private byte[] data;
        //1 byte,start number of data
        private byte[] startByte;
        //1 byte,meter type of data
        private byte[] meterType;
        //meter number,7 bytes
        private byte[] meterNumber;
        //1 byte,control number
        private byte[] controlNumber;
        //1 byte,length of data feild 
        private byte[] length;
        //dataField 
        private byte[] dataField;
        //1 byte,verification
        private byte[] verifyNumber;
        //1 byte,indicate the end of data, hexdicmal number 16
        private byte[] endByte;

        public byte[] ControlNumber { get { return controlNumber; } }
        public byte[] DataField { get { return dataField; } }
        //error string
        private string errorString;
        public AnalysisDataPack(byte[] data)
        {
            this.data = new byte[data.Length];
            Array.Copy(data, 0, this.data, 0, data.Length);
        }

        //test verify number equivalent 
        //parameter: data:data array, verifyCode:test code to compare
        //return: if calculte verify equal to verifyCode ,return true,otherwise return false
        public bool CalculateVerifyNumber(byte[] data, byte verifyCode)
        {
            if (data == null)
            {
                errorString = "Can't pass null to CalculateVerifyNumber function";
                return false;
            }
            int temp = 0;
            for (int i = 0; i < data.Length - 2; i++)
            {
                temp = (temp + data[i]) % 256;
            }
            if ((byte)temp == verifyCode)
                return true;
            errorString = data.ToString() + " don't match " + verifyCode.ToString();
            return false;
        }

        public bool Analysis()
        {
            if (data.Length < 15) return false;
            int index = 0;
            //if no data can analysis,we quit
            if (data == null)
            {
                errorString = "analysis incorrect,data is empty";
                return false;
            }
            //copy start number
            startByte = new byte[1];
            Array.Copy(data, 0, startByte, 0, 1);
            index++;
            //copy meter type number
            meterType = new byte[1];
            Array.Copy(data, index, meterType, 0, 1);
            index++;
            //copy meterNumber
            meterNumber = new byte[7];
            Array.Copy(data, index, meterNumber, 0, 7);
            index += 7;
            //copy control number
            controlNumber = new byte[1];
            Array.Copy(data, index, controlNumber, 0, 1);
            index++;
            //copy data length
            length = new byte[1];
            Array.Copy(data, index, length, 0, 1);
            index++;
            //copy data feild
            dataField = new byte[length[0]];
            Array.Copy(data, index, dataField, 0, length[0]);
            index += length[0];
            //copy verify number
            verifyNumber = new byte[1];
            Array.Copy(data, index, verifyNumber, 0, 1);
            index++;
            //copy end number
            endByte = new byte[1];
            Array.Copy(data, index, endByte, 0, 1);
            index++;

            //calculate verify code
            if (CalculateVerifyNumber(data, verifyNumber[0])) return true;
            errorString = "code verify incorrect!";
            return false;
        }

        public int GetD0D1()
        {
            byte[] d0d1 = new byte[2];
            Array.Copy(dataField, 0, d0d1, 0, 2);
            int temp = d0d1[1];
            temp += d0d1[0] * 256;
            return temp;
        }
    }
}
