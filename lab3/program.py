
# Subject: Empirical analysis of algorithms for obtaining Eratosthenes Sieve.

import algorithms
import time
import csv

if __name__ == "__main__":

    resultsList = []  # list of lists of the results for all inputs

    with open("timeComplexityResults.csv", "w") as tCR:
        Writer = csv.writer(tCR, delimiter=',')
        Writer.writerow(['range', 'firstAlgo', 'secondAlgo',
                            'thirdAlgo', 'fourthAlgo', 'fifthAlgo'])

    numInputBox = [100, 1000, 10000, 50000, 100000, 200000]
    for numInput in numInputBox:

        batchOfResults = []
        num = numInput
        batchOfResults.append(num)

        startTime = time.time()
        algorithms.firstAlgorithm(num)
        timeOfExecution = time.time() - startTime
        batchOfResults.append(timeOfExecution)
        # print("first algo done")

        startTime = time.time()
        algorithms.secondAlgorithm(num)
        timeOfExecution = time.time() - startTime
        batchOfResults.append(timeOfExecution)
        # print("second algo done")

        startTime = time.time()
        algorithms.thirdAlgorithm(num)
        timeOfExecution = time.time() - startTime
        batchOfResults.append(timeOfExecution)
        # print("third algo done")

        startTime = time.time()
        algorithms.fourthAlgorithm(num)
        timeOfExecution = time.time() - startTime
        batchOfResults.append(timeOfExecution)
        # print("fourth algo done")

        startTime = time.time()
        algorithms.fifthAlgorithm(num)
        timeOfExecution = time.time() - startTime
        batchOfResults.append(timeOfExecution)
        # print("fifth algo done")

        print(batchOfResults)

        resultsList.append(batchOfResults)

    with open("timeComplexityResults.csv", "a") as tCR:
        Writer = csv.writer(tCR, delimiter=',')
        for i in range(len(resultsList)):
            Writer.writerow(resultsList[i])
