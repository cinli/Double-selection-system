using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Double_selection_systemModel
{
    [Serializable]
    public class Teacher
    {
        /// <summary>
        /// 将数据库中的teacher表对应一个类
        /// </summary>
        private string _name;
        private int _age;
        private int _teachYear;
        private int _id;
        private int _gradeId;
        private string _pwd;
        private string _title;
        private string _introduction;

        public string Name { get => _name; set => _name = value; }
        public int Age { get => _age; set => _age = value; }
        public int TeachYear { get => _teachYear; set => _teachYear = value; }
        public int Id { get => _id; set => _id = value; }
        public int GradeId { get => _gradeId; set => _gradeId = value; }
        public string Pwd { get => _pwd; set => _pwd = value; }
        public string Title { get => _title; set => _title = value; }
        public string Introduction { get => _introduction; set => _introduction = value; }
    }
}
