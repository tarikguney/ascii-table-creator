using System.Data;
using System.Globalization;
using System.Text;

namespace AsciiTableGenerators
{
	public static class AsciiTableGenerator
	{
		private const string COLUMN_SEPARATOR = " | ";
		private const string ALIGN_CHAR = " ";
		private const string HEADER_SEPARATOR = "-";
		
		public static StringBuilder CreateAsciiTableFromDataTable(DataTable table)
		{
			var tableBuilder = new StringBuilder();
			var lengthByColumn = GetLengthByColumn(table);
			AppendColumns(table, tableBuilder, lengthByColumn);
			AppendRows(table, tableBuilder, lengthByColumn);

			return tableBuilder;
		}

		private static Dictionary<int, int> GetLengthByColumn(DataTable table)
		{
			var lengthByColumn = new Dictionary<int, int>();

			for (var columnIndex = 0; columnIndex < table.Columns.Count; columnIndex++)
			{
				var rowsLengths = new int[table.Rows.Count];

				for (var rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
				{
					rowsLengths[rowIndex] = table.Rows[rowIndex][columnIndex].ToString()?.Trim().Length ?? 0;
				}

				lengthByColumn[columnIndex] = Math.Max(rowsLengths.Max(), table.Columns[columnIndex].ColumnName.Trim().Length);
			}

			return lengthByColumn;
		}

		private static void AppendColumns(DataTable table, StringBuilder tableBuilder, IReadOnlyDictionary<int, int> lengthByColumn)
		{
			for (var columnIndex = 0; columnIndex < table.Columns.Count; columnIndex++)
			{
				var columName = table.Columns[columnIndex].ColumnName.Trim();
				var paddedColumNames = AlignValueAndAddSeparator(ToTitleCase(columName), lengthByColumn[columnIndex]);
				tableBuilder.Append(paddedColumNames);
			}

			tableBuilder.AppendLine();
			tableBuilder.AppendLine(string.Join("", Enumerable.Repeat(HEADER_SEPARATOR, tableBuilder.ToString().Length - 3).ToArray()));
		}

		private static string ToTitleCase(string columnName)
		{
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(columnName.Replace("_", " "));
		}

		private static void AppendRows(DataTable table, StringBuilder tableBuilder, IReadOnlyDictionary<int, int> lengthByColumn)
		{
			for (var rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
			{
				var rowBuilder = new StringBuilder();

				for (var columnIndex = 0; columnIndex < table.Columns.Count; columnIndex++)
				{
					rowBuilder.Append(AlignValueAndAddSeparator(table.Rows[rowIndex][columnIndex].ToString()?.Trim(), lengthByColumn[columnIndex]));
				}

				tableBuilder.AppendLine(rowBuilder.ToString());
			}
		}

		private static string AlignValueAndAddSeparator(string? value, int columnLength)
		{
			var spaces = string.Empty;
			
			if (value != null)
			{
				var remainingSpace = value.Length < columnLength ? columnLength - value.Length : value.Length - columnLength;
				spaces = string.Join("", Enumerable.Repeat(ALIGN_CHAR, remainingSpace).ToArray());
			}

			return value + spaces + COLUMN_SEPARATOR;
		}
	}
}