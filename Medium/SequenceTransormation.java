import java.io.*;
public class Main {
    static int[][] mem;
    
    private static boolean isPossible(String b, String t, char constraint)
    {
        
        int bn = b.length(), tn = t.length();
        if(mem[bn][tn] > 0)
            return mem[bn][tn] == 1 ? true : false;
        
        if(bn == 0 && tn == 0)
            return true;
        if(bn == 1 && tn == 1)
            return b.charAt(0) == '0' ? t.charAt(0) == 'A' : true;
        if(bn == 0 || tn == 0)
            return false;
        boolean res;
        res = 
            (b.charAt(0) == '0' ? t.charAt(0) == 'A' : constraint == '0' || constraint == t.charAt(0))
            &&
            (isPossible(b.substring(0, bn), t.substring(1, tn), t.charAt(0))
            || isPossible(b.substring(1, bn), t.substring(1, tn), '0'));
            
        mem[bn][tn] = res ? 1 : 2;   
        
        return res;
    }
    public static void main (String[] args) throws Exception {
    File file = new File(args[0]);
    BufferedReader in = new BufferedReader(new FileReader(file));
    String line;
    while ((line = in.readLine()) != null) {
        String[] lineArray = line.split("\\s");
        if (lineArray.length> 0) {
            //Process line of input Here
            mem = new int[lineArray[0].length()+1][lineArray[1].length()+1];
            if(isPossible(lineArray[0], lineArray[1], '0' ))
                System.out.println("Yes");
            else
                System.out.println("No");
            
        }
    }
  }
}
