package example;

import java.io.IOException;

import org.apache.hadoop.io.Text;
import org.apache.hadoop.mapreduce.Reducer;

public class NameYearReducer extends
		Reducer<StringPairWritable, Text, Text, Text> {

	@Override
	public void reduce(StringPairWritable key, Iterable<Text> values,
			Context context) throws IOException, InterruptedException {

		/*
		 * For each value in the set of values passed to us by the mapper
		 * emit only the FIRST of its values.
		 * 
		 * Input: (John, 1990) [file1.csv, file2.csv, file3.csv]
		 * Output: (John, file1.csv)
		 */

		context.write(new Text(""),values.iterator().next());
	}
}