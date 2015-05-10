namespace Hxj.Tools.EntityDesign.Model
{
    using System;

    public class ColumnInfo
    {
        private bool _cisNull;
        private string _colorder;
        private string _columnName;
        private string _defaultVal;
        private string _deText;
        private bool _isIdentity;
        private bool _ispk;
        private string _length;
        private string _preci;
        private string _scale;
        private string _typeName;

        public bool cisNull
        {
            get
            {
                return this._cisNull;
            }
            set
            {
                this._cisNull = value;
            }
        }

        public string Colorder
        {
            get
            {
                return this._colorder;
            }
            set
            {
                this._colorder = value;
            }
        }

        public string ColumnName
        {
            get
            {
                return this._columnName;
            }
            set
            {
                this._columnName = value;
            }
        }

        private string _columnNameRealName;

        public string ColumnNameRealName
        {
            get
            {
                return this._columnNameRealName;
            }
            set
            {
                this._columnNameRealName = value;
            }
        }


        public string DefaultVal
        {
            get
            {
                return this._defaultVal;
            }
            set
            {
                this._defaultVal = value;
            }
        }

        public string DeText
        {
            get
            {
                return this._deText;
            }
            set
            {
                this._deText = value;
            }
        }

        public bool IsIdentity
        {
            get
            {
                return this._isIdentity;
            }
            set
            {
                this._isIdentity = value;
            }
        }

        public bool IsPK
        {
            get
            {
                return this._ispk;
            }
            set
            {
                this._ispk = value;
            }
        }

        public string Length
        {
            get
            {
                return this._length;
            }
            set
            {
                this._length = value;
            }
        }

        public string Preci
        {
            get
            {
                return this._preci;
            }
            set
            {
                this._preci = value;
            }
        }

        public string Scale
        {
            get
            {
                return this._scale;
            }
            set
            {
                this._scale = value;
            }
        }

        public string TypeName
        {
            get
            {
                return this._typeName;
            }
            set
            {
                this._typeName = value;
            }
        }
    }
}

