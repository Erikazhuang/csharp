limitation/problems:
It is a console app knocked up quickly, it takes user input from args assuming user type chromosome first and then position, i.e VcfParser\bin\Debug\net5.0\vcfParser.exe chr1 10044
it take one chromosome & positions at a time, although it can be easily to extended to accept array of chromosome & positions 
limited configuration for input file
search field name 'CHROM' and 'POS' are hardcoded, should be move to configuration
It has limited logging
It currently print results to screen


How would it scale?
It currently loads in all columns and rows from the file. For mega file with large datasets, it should read chunks at a time and load only required columns rather than all columns.
It currently returns string result, it can easily be extended to export from the DataTable to downstream database, xml, or json format for API usage 
Factor out the configuration of input file should make it more versatile and cater for different file formats


How would you test it effeciently
I will create a unit test project, unit test each methods
Fix any bugs and rerun the test until all tests pass
On top of that, I'll run with corrupted file, file that contains no records, file with large amount of records to check error handling and performance
