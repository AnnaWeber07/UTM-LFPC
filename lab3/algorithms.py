# library of the algorithms

import math

def firstAlgorithm(n):
    c = [True] * n

    c[0] = False
    i = 2

    while i < n:
        if c[i]:
            j = 2 * i
            while j < n:
                c[j] = False
                j += i
        i += 1

    # for i in range(n):
    #     if c[i]:
    #         print(i)


def secondAlgorithm(n):
    
    c = [True] * n

    c[0] = False
    i = 2

    while i < n:
        j = 2 * i
        while j < n:
            c[j] = False
            j += i
        i += 1

    # for i in range(n):
    #     if c[i]:
    #         print(i)


def thirdAlgorithm(n):
    c = [True] * n

    c[0] = False
    i = 2
   # j = 2

    while i < n:
        if c[i]:
            j = i + 1
            while j < n:
                if not j % i:
                    c[j] = False
                j += 1
        i += 1

    # for i in range(n):
    #     if c[i]:
    #         print(i)

def fourthAlgorithm(n):

    c = [True] * n

    c[0] = False
    i = 2

    while i < n:
        j = 2
        while j < i:
            if i % j == 0:
                c[i] = False
            j += 1
        i += 1

    # for i in range(n):
    #     if c[i]:
    #         print(i)


def fifthAlgorithm(n):

    c = [True] * n

    c[0] = False
    i = 2

    while i < n:
        j = 2
        while j < math.sqrt(i):
            if not i % j:
                c[i] = False
            j += 1
        i += 1

    # for i in range(n):
    #     if c[i]:
    #         print(i)
