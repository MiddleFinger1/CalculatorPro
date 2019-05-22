import math

"""
здесь содержаться основные встроенные функции:
    1) factorial
    2) degree
    3) radian
    4) maximal
    5) minimal
    6) absolute
    7) middleArg
    8) exponent
    9) logarithm
"""

def middleArg(*args):
    summ = 0
    for i in args:
        summ += i
    return summ / len(args)

def factorial(number):
	if number == 0:
		return 1
	return factorial(number - 1) * number

def exponent(number): return math.e ** number

def logarithm(number, base): return math.log(number, base)

def degree(radian): return (180 / math.pi) * radian

def radian(degree): return (math.pi / 180) * degree

def maximal(*args):
    answer = []
    while len(answer) < len(args):
        answer.append("*")
    for i in args:
        c = 0
        for h in args:
            if i > h:
                c += 1
        answer[c] = i
    answer.reverse()
    return answer[0] 

def minimal(*args):
    answer = []
    while len(answer) < len(args):
        answer.append("*")
    for i in args:
        c = 0
        for h in args:
            if i < h:
                c += 1
        answer[c] = i
    answer.reverse()
    return answer[0] 


def absolute(number): return (number ** 2)** 0.5

