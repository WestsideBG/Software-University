import java.util.Scanner;

public class sumTwoNums {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        double num1 = Double.parseDouble(sc.nextLine());
        double num2 = Double.parseDouble(sc.nextLine());
        double sum = num1 + num2;

        System.out.println(sum);

    }
}
