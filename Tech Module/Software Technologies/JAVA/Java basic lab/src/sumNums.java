import java.util.Scanner;

public class sumNums {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int n = Integer.parseInt(sc.nextLine());
        int sum = 0;
        for (int i = 0; i < n; i++) {

        int currNum = Integer.parseInt(sc.nextLine());

        sum += currNum;

        }

        System.out.println(sum);
    }
}
