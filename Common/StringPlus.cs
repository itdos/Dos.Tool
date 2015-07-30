/* 字符操作 */
using System;
using System.Text;

namespace Hxj.Tools.EntityDesign
{
    public class StringPlus
    {
        private StringBuilder str = new StringBuilder();

        public string Append(string Text)
        {
            this.str.Append(Text);
            return this.str.ToString();
        }
        /// <summary>
        /// 添加空行
        /// </summary>
        /// <returns></returns>
        public string AppendLine()
        {
            this.str.Append("\r\n");
            return this.str.ToString();
        }
        /// <summary>
        /// 添加一行字符串
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public string AppendLine(string Text)
        {
            this.str.Append(Text + "\r\n");
            return this.str.ToString();
        }
        /// <summary>
        /// 添加若干个空格符后的文本内容
        /// </summary>
        /// <param name="SpaceNum"></param>
        /// <param name="Text"></param>
        /// <returns></returns>
        public string AppendSpace(int SpaceNum, string Text)
        {
            this.str.Append(this.Space(SpaceNum));
            this.str.Append(Text);
            return this.str.ToString();
        }
        /// <summary>
        /// 添加若干个空格符后的文本，并换行
        /// </summary>
        /// <param name="SpaceNum">空格数</param>
        /// <param name="Text"></param>
        /// <returns></returns>
        public string AppendSpaceLine(int SpaceNum, string Text)
        {
            this.str.Append(this.Space(SpaceNum));
            this.str.Append(Text);
            this.str.Append("\r\n");
            return this.str.ToString();
        }
        /// <summary>
        /// 删除末尾指定字符串
        /// </summary>
        /// <param name="strchar"></param>
        public void DelLastChar(string strchar)
        {
            string str = this.str.ToString();
            int length = str.LastIndexOf(strchar);
            if (length > 0)
            {
                this.str = new StringBuilder();
                this.str.Append(str.Substring(0, length));
            }
        }
        /// <summary>
        /// 删除最后一个逗号
        /// </summary>
        public void DelLastComma()
        {
            string str = this.str.ToString();
            int length = str.LastIndexOf(",");
            if (length > 0)
            {
                this.str = new StringBuilder();
                this.str.Append(str.Substring(0, length));
            }
        }

        public void Remove(int Start, int Num)
        {
            this.str.Remove(Start, Num);
        }
        /// <summary>
        /// 空格串
        /// </summary>
        /// <param name="SpaceNum"></param>
        /// <returns></returns>
        public string Space(int SpaceNum)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < SpaceNum; i++)
            {
                builder.Append("\t");  //制表符
            }
            return builder.ToString();
        }

        public override string ToString()
        {
            return this.str.ToString();
        }

        public string Value
        {
            get
            {
                return this.str.ToString();
            }
        }
    }
}

