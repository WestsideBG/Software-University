import java.util.Scanner;

public class boolVar {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String input = sc.nextLine();

        if (input.equals("True"))
        {
            System.out.println("Yes");
        }
        else
        {
            System.out.println("No");
        }
    }
}
