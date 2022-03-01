using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey_App
{
    class Survey
    {
        /// <summary>
        /// This section will hold the fields age, name, submissionDate, and title
        /// </summary>
        #region Fields
        private string _age;
        private string _name;
        private DateTime _submissionDate;
        private string _title;

        /// <summary>
        /// Will hold the properties Age, Name, SubmissionDate, and Title
        /// </summary>
        #region Properties
        public string Age
        {
            get { return _age; }
            set { _age = value.Trim(); }
        }
        
        public string Name
        {
            get { return _name; }
            set { _name = value.Trim(); }
        }

        public DateTime SubmissionDate
        {
            get { return _submissionDate; }
            set { _submissionDate = value; }
        }

        public string Title
        {
            get { return _title; }
                set { _title = value.Trim(); }
        }

        #endregion

        /// <summary>
        /// Methods of the class; constructor, destructor, ToString
        /// </summary>
        #region Methods
        //default contructor
        public Survey()
        {
            
        }

        //overloaded constructor
        public Survey(string pAge, string pName, DateTime pSubmissionDate, string pTitle)
        {
            Age = pAge;
            Name = pName;
            SubmissionDate = pSubmissionDate;
            Title = pTitle;
        }

        //destructor
        ~Survey()
        {
            _age = null;
            _name = null;
            _title = null;
        }
        #endregion

        public override string ToString()
        {
            string message = Title + " " + Name + " (" + Age + ") submitted on " + SubmissionDate.ToString("d");           
            return message;
        }
        #endregion
    }
}
