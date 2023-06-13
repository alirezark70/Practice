using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEfConfiguration.Models
{
    public class BackingFieldEntity
    {
        public int Id { get; set; }

        #region Fields
        private string _firstNameField;
        #endregion


        [BackingField("_firstNameField")]
		public string FirstName
		{
			get { return _firstNameField; }
			set { _firstNameField = value; }
		}



	}
}
