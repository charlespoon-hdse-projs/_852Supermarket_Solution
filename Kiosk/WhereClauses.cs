using System;
using System.Collections.Generic;

namespace SDP_02
{	
	internal class WhereClause {
		internal String column { get; private set; }
		internal object value { get; private set; }
		public WhereClause(string colunm, object value)
		{
			this.column = colunm;
			this.value = value;
		}
		public override string ToString()
		{
			if (this.value.GetType() == typeof (string)) {
				return this.column + "=\'" + (string) this.value + "\'";
			} else {
				return this.column + "=" + this.value.ToString();
			}
		}

	}
}
