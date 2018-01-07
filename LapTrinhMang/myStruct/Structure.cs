using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Drawing;
namespace myStruct
{
    [Serializable()]

    public class Structure : ISerializable
    {
        private string _textChat;
        private Font _myFont;
        private Color _myColor;

        public Structure()
        {
            this._textChat = null;
            this._myFont = new Font("Arial",10,FontStyle.Regular);
            this._myColor = Color.Blue;
        }
        public Structure(String text , Font ft ,Color cl)
        {
            this.TextChat = text;
            this.MyFont = ft;
            this.MyColor = cl;
        }
        public Structure(Structure str)
        {
            this.TextChat = str.TextChat;
            this.MyFont = str.MyFont;
            this.MyColor = str.MyColor;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext strcxt)
        {
            info.AddValue("text", this.TextChat);
            info.AddValue("font", this.MyFont);
            info.AddValue("color", this.MyColor);
        }
        public  Structure(SerializationInfo info, StreamingContext strcxt)
        {
            this.TextChat = (string)info.GetValue("text", typeof(string));
            this.MyFont = (Font)info.GetValue("font", typeof(Font));
            this.MyColor = (Color)info.GetValue("color", typeof(Color));
        }
        public Color MyColor
        {
            get { return _myColor; }
            set { _myColor = value; }
        }

        public Font MyFont
        {
            get { return _myFont; }
            set { _myFont = value; }
        }
        public string TextChat
        {
            get { return _textChat; }
            set { _textChat = value; }
        }
    
    
    }
}
