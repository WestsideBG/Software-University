import java.util.Scanner;

public class symetricNums {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int num = Integer.parseInt(sc.nextLine());

        for (int i = 0; i < num; i++) {



            if (isSemetric(i))
            {
                System.out.println(i);
            }

        }


    }

    static boolean isSemetric (int number) {

        int temp;
        boolean answer = true;

        while (number != 0) {

            temp = number % 10;
            number /= 10;

            if (temp != (number%10)) {
                answer = false;
            } else {
                answer = true;
            }

        }

        return answer;

    }
}
