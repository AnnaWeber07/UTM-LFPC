package annachiriciuc;

import java.io.IOException;

//9 вариант
//Anna Chiriciuc
public class NfaToDfa {
    public static void main(String[] args)
            throws IOException {
        buildAndShow("finished.dot");
    }

    public static void buildAndShow(String fileName)
            throws IOException {

        if (fileName == "finished.dot") {
            Nfa nfa = new Nfa(0, 4);
            nfa.addTrans(0, "A", 1);
            nfa.addTrans(1, "B", 2);
            nfa.addTrans(2, "C", 0);
            nfa.addTrans(1, "B", 3);
            nfa.addTrans(3, "A", 4);
            nfa.addTrans(3, "B", 0);
            System.out.println(nfa);
            Dfa dfa = nfa.toDfa();
            System.out.println(dfa);
            System.out.println("Writing DFA graph to file: " + fileName);
            dfa.writeDot(fileName);
            System.out.println();
        }

    }
}
