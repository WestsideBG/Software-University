import java.util.Scanner;

public class hexToDec {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        String hex = sc.nextLine();

        int dec = Integer.parseInt(hex,16);

        System.out.println(dec);
    }
}
