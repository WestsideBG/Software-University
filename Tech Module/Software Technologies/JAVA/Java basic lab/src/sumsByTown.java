import java.util.Scanner;
import java.util.TreeMap;

public class sumsByTown {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int n = Integer.parseInt(sc.nextLine());

        TreeMap<String, Double> collection = new TreeMap<>();

        for (int i = 0; i < n; i++) {

            String[] arr = sc.nextLine().split(" \\| ");

            String town = arr[0].trim();
            double income = Double.parseDouble(arr[1]);

            if (!collection.containsKey(town))
            {
                collection.put(town,income);
            }
            else
            {
                collection.put(town,collection.get(town) + income);
            }

        }

        collection.forEach((key, value) -> System.out.println(
                String.format("%s -> %.1f", key, value)
        ));
    }
}
