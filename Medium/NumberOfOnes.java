import java.io.*;
public class Main {
    public static void main (String[] args) throws Exception{

    File file = new File(args[0]);
    BufferedReader in = new BufferedReader(new FileReader(file));
    String line;
    while ((line = in.readLine()) != null) {
        String[] lineArray = line.split("\\s");
        if (lineArray.length > 0) {
            int num = Integer.parseInt(lineArray[0]);
            int res = 0;
            int one = 1;
            while(num > 0)
            {
                if((num & one) != 0)
                    ++res;
                num >>= 1;
            }
            System.out.println(res);
            //Process line of input Here
        }
    }
  }
}
