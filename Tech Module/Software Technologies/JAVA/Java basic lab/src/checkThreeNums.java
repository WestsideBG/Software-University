import java.util.Scanner;

public class checkThreeNums {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        int num1 = sc.nextInt();
        int num2 = sc.nextInt();
        int num3 = sc.nextInt();

        if (num1 + num2 == num3)
        {
            System.out.printf("%d + %d = %d", Math.min(num1,num2), Math.max(num2,num1), num3);
        }
        else if (num1 + num3 == num2)
        {
            System.out.printf("%d + %d = %d", Math.min(num1,num3), Math.max(num3,num1), num2);
        }
        else if (num2 + num3 == num1)
        {
            System.out.printf("%d + %d = %d", Math.min(num3,num2), Math.max(num2,num3), num1);
        }
        else
        {
            System.out.println("No");
        }

    }
}
