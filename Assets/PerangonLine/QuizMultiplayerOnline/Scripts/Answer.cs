using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Perangonline.PhotonQuis
{
    public class Answer
    {
        private int _ID;
        private string _Desc;
        private bool _isTrue;

        public Answer()
        {
        }

        public Answer(int ID, string desc, bool isTrue)
        {
            Id = ID;
            Description = desc;
            IsTrue = isTrue;
        }

        public int Id
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        public string Description
        {
            get
            {
                return _Desc;
            }

            set
            {
                _Desc = value;
            }
        }

        public bool IsTrue
        {
            get
            {
                return _isTrue;
            }

            set
            {
                _isTrue = value;
            }
        }
    }
}
