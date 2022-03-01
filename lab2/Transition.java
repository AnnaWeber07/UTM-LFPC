package annachiriciuc;

public class Transition {
    String lab;
    Integer target;

    public Transition(String lab, Integer target) {
        this.lab = lab;
        this.target = target;
    }

    public String toString() {
        return "-" + lab + "-> " + target;
    }
}