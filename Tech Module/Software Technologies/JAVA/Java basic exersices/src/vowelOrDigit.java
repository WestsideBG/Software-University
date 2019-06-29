import java.util.Scanner;

public class vowelOrDigit {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        char ch = sc.nextLine().charAt(0);



        if (ch == 'a' || ch == 'o' || ch == 'e' || ch == 'i' || ch == 'u')
        {
            System.out.println("vowel");
        }
        else if (ch >= 48 && ch <= 57)
        {
            System.out.println("digit");
        }
        else
        {
            System.out.println("other");
        }
    }
}
