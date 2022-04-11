using System.Data;

namespace AsciiTableGenerators;

public class AsciiTableGeneratorTests
{
	// NUnit was used. 11.04.2022. Artem Yurchenko
	
	// [Test]
	// public void CreateTableWithHeadersOnly_GeneratorReturnsExpectedString_True ()
	// {
	// 	DataTable table = new();
	// 	table.Columns.Add("Column1");
	// 	table.Columns.Add("Column2");
	// 	
	// 	string tableString = AsciiTableGenerator.CreateAsciiTableFromDataTable(table).ToString();
	// 	
	// 	Assert.AreEqual("Column1 | Column2 | \n-------------------\n", tableString);
	// }
	//
	// [Test]
	// public void CreateSimpleTable_GeneratorReturnsExpectedString_True ()
	// {
	// 	DataTable table = new();
	// 	table.Columns.Add("Column1");
	// 	table.Columns.Add("Column2");
	// 	table.Rows.Add("Row1", "Row2");
	// 	
	// 	string tableString = AsciiTableGenerator.CreateAsciiTableFromDataTable(table).ToString();
	// 	
	// 	Assert.AreEqual("Column1 | Column2 | \n-------------------\nRow1    | Row2    | \n", tableString);
	// }
	//
	// [Test]
	// public void CreateTableWithRowBiggerThanColumn_GeneratorReturnsExpectedString_True ()
	// {
	// 	DataTable table = new();
	// 	table.Columns.Add("Column1");
	// 	table.Rows.Add("Column1Bigger");
	// 	
	// 	string tableString = AsciiTableGenerator.CreateAsciiTableFromDataTable(table).ToString();
	// 	
	// 	Assert.AreEqual("Column1       | \n---------------\nColumn1Bigger | \n", tableString);
	// }
}