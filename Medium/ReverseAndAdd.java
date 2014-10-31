import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;


public class Main {
    public static void main (String[] args) throws Exception {

    File file = new File(args[0]);
    BufferedReader in = new BufferedReader(new FileReader(file));
    String line;
    while ((line = in.readLine()) != null) {
        String[] lineArray = line.split("\\s");
        int n = lineArray.length;
        if (n > 0) {
            for(int i = 0 ;i < n; ++i) {
                int inp = Integer.parseInt(lineArray[0]);
                int[] ans = go(inp);
                System.out.println(ans[0] + " " + ans[1]);
            }
        }
    }
  }

    private static int[] go(int inp) {
        int[] res = new int[2];
        int i = 0;

        boolean isPal = false;
        do
        {
           i++;

           int sum = inp+getReverse(inp);
           isPal = isPalindrome(sum);
           inp = sum;

        }while(!isPal);
        res[0] = i;
        res[1] = inp;
        return res;
    }

    private static boolean isPalindrome(int num) {
        return num == getReverse(num);
    }

    private static int getReverse(int inp) {
        int t = 0;
        while(inp > 0)
        {
            int rem = inp%10;
            inp/=10;
            t*=10;
            t+=rem;
        }
        return t;
    }
}
