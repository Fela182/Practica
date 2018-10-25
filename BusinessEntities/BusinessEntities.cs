using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BusinessEntities
    {
        public BusinessEntities()
        {
            State = States.New;
        }
            
          

        private int _ID;
        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }

        public enum States
        {
            New,
            Modified,
            Delete,
            Unmodified
        }

        private States _State;
        public States State
        {
            set { _State = value; }
            get { return _State; }
        }

    }
}
