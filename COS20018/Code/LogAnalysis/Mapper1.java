package LogAnalysis;

import java.io.IOException;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.apache.hadoop.io.Text;
import org.apache.hadoop.io.IntWritable;
import org.apache.hadoop.io.LongWritable;
import org.apache.hadoop.mapreduce.Mapper;


public class Mapper1 extends Mapper<LongWritable, Text, Text, IntWritable> {

    private final static IntWritable one = new IntWritable(1);
    private Text word = new Text();

    @Override
    protected void map(LongWritable key, Text value, Context context)
        throws IOException, InterruptedException {
        
        // Format: 192.168.0.1 - - [12/Dec/2020:10:15:30 +0000] "GET /index.html HTTP/1.1" 200 1024
        String line = value.toString();
        String regex = "^(\\d{1,3}(?:\\.\\d{1,3}){3}) (\\S+) (\\S+) \\[([^\\]]+)\\] \"([^\"]+)\" (\\d{3}) (\\d+|-)$";
        Matcher m = Pattern
            .compile(regex)
            .matcher(line);

        if (m.find()) {
            String[] date = m.group(4).split("/"); // e.g., 12/Dec/2020:10:15:30 +0000
            String ip = m.group(1);   // e.g., 192.168.0.1
            String day = date[0]; // e.g., 12
            String month = date[1]; // e.g., Dec
            String year = date[2].split(":")[0]; // e.g., 2020
        }
    }
}