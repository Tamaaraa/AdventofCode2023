import os

def create_folders(count):
    for i in range(count):
        name="./day_{:02d}".format(i+1)
        os.makedirs(name)
        open(f"{name}/input", "w")

if __name__ == "__main__":
    create_folders(24)