using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject
{
    public class Teacher
    {
        private string _name;
        private string _description;
        public event EventHandler<TeacherNameChangeArg> _TeacherNameChange;
        public Teacher(string name, string Family)
        {
            _name = name;
            _description = Family;
        }

        public void SetName(string NewName)
        {
            var arg = new TeacherNameChangeArg(_name, NewName);
            this._name = NewName;
            _TeacherNameChange.Invoke(this,arg);
        }

    }

}
