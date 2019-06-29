import java.lang.reflect.Array;
import java.util.Arrays;
import java.util.Scanner;

public class largestThreeNums {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int[] numbs = Arrays.stream(sc.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        Arrays.sort(numbs);

        for (int i = numbs.length-1; i >= 0; i--) {

            if (i == numbs.length-4)
            {
                break;
            }

            System.out.println(numbs[i]);

        }
    }
}
