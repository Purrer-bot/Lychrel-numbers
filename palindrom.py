#!/usr/bin/env python3
# -*- coding: utf-8 -*-
import random

'''Для полоижетльных чисел '''
def generate_numbers(n = 1):
    gen_list = []
    #for i in range(100,300):
    for i in range(n):
        #gen_list.append(random.randint(100,900))
        #gen_list.append(i)
        gen_list.append(295)
        #gen_list.append(int(input("Ввести число ")))
    return gen_list

#БАГ! Если палиндром изначально, цикл испольняется один раз
def palindrome(gen_list):
    ITER = 200
    for i in gen_list:
        j = str(i)
        print("Исходное число ", j)
        k = 0
        while j != j[::-1] or k<=ITER:
            k+=1
            j_sum = get_numbers_sum(j)
            j_rev_sum = get_numbers_sum(j[::-1])

            print("Промежуточный результат: ",j," реверс ", j[::-1])
            print("Сумма цифр первого числа = ",j_sum," реверса ", j_rev_sum, " итерация ", k)
            j = str(int(j)+int(j[::-1]))
            if k >= ITER:
                break
            if j == j[::-1]:
                print("Палиндром для числа ",i," = ",j,", число итераций = ",k)
                print("Сумма цифр палиндрома ", get_numbers_sum(j))
                print("=================================================")
                break

def get_numbers_sum(a):
    result = 0
    for i in range(len(a)):
        result += int(a[i])
    return result
'''Для отрицательных чисел '''
def reverse(j):
    k = int(str(j).strip("-"))
    n = ''
    while k != 0:
        n = n+ str(k%10)
        #print(int(s))
        k = k//10
    return int(n)

#j = int(input("Ввести число j "))
#print(reverse(j))

def minus(gen_list):
     num = [1,2,3,4,5,6,7,8,9,0]
     for i in gen_list:
        j = int(i)
        if j in num:
            #print "Минус-палиндром для числа",i, "=", 0 ,"число итераций",0
            break
        k = 0
        while k <=1000:
            j = j - reverse(j)
            k+=1
            l = str(j)
            if l.strip("-") == l[::-1].strip("-"):
                #print "Минус-палиндром для числа",i, "=",j,"число итераций",k
                break
    return 0
n = 1
a = generate_numbers(n)
minus(a)
#palindrome(a)
