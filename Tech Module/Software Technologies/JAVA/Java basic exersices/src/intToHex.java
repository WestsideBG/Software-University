import java.util.Scanner;

public class intToHex {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int n = Integer.parseInt(sc.nextLine());

        String hex = Integer.toHexString(n);
        String binary = Integer.toBinaryString(n);

        System.out.println(hex.toUpperCase());
        System.out.println(binary);
    }
}
