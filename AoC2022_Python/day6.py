file = open("input.txt", "r")

chars = [*file.readline()]

skip = 0
take = 14

while True:
    if len(set(chars[skip:take])) == 14:
            break
    skip+=1
    take+=1

print(take)