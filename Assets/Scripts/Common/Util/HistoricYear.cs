using System;



namespace Common.Util
{
	/* TODO: handle zero
	 */
	public struct HistoricYear
	{
		private int _year;


		public HistoricYear(int year)
		{
			this._year = year;
		}


		public override string ToString()
		{
			string number = Math.Abs(_year).ToString();
			string postfix = _year < 0 ? "BC" : "AD";

			return $"{number} {postfix}";
		}
	}
}
