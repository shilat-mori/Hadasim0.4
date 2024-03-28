from abc import abstractmethod, ABC
import numpy as np


class NotValidInput(Exception):
    pass


class Tower(ABC):
    def __init__(self):
        self._width ,self._height = enter_size()
        self._tower = []

    @staticmethod
    def pythagorean(x, y):
        c = np.sqrt(np.power(x, 2) + np.power(y, 2))
        return c

    @abstractmethod
    def perimeter(self):
        pass

    @abstractmethod
    def area(self):
        pass

    def _print_tower(self):
        for floor in self._tower:
            spaces = int((self._width - floor) / 2)
            print(' ' * spaces + '*' * floor + ' ' * spaces)


class Rectangle(Tower):
    def __init__(self):
        super().__init__()
        self._tower = [self._width] * self._height

    def get_height(self):
        return self._height

    def get_width(self):
        return self._width

    def perimeter(self):
        print(f'the perimeter is {self._width * 2 + self._height * 2}')
        return self._width * 2 + self._height * 2

    def area(self):
        print(f'the area is {(self._width * self._height)}')
        return self._width * self._height

    def print_tower(self):
        super()._print_tower()



class Triangle(Tower):
    def __init__(self):
        super().__init__()
        if self._width % 2 == 0:
            raise NotValidInput('cannot print the triangle')
        elif self._height * 2 < self._width:
            raise NotValidInput('the triangle is not valid!')
        # self.__delattr__()

        rng = range(1, self._width + 1, 2)
        print(rng, (len(rng)))

        self._tower = [rng[0]] + np.repeat(rng[1:-1], int((self._height - 2) / (len(rng) - 1))).tolist() + [rng[-1]]

        if (self._height - len(self._tower)) > 0:
            [self._tower.insert(1, self._tower[1]) for _ in range(self._height - len(self._tower))]

    def get_height(self):
        return self._height

    def get_width(self):
        return self._width

    def perimeter(self):
        base = self._width
        side = Tower.pythagorean(self._width / 2, self._height)
        print(f'the perimeter is {base + side1 + side2}')
        return base + (side*2)

    def area(self):
        print(f'the area is {(self._width * self._height) / 2}')
        return (self._width * self._height) / 2

    def print_tower(self):
        super()._print_tower()



def enter_size():
    height = ''
    width = ''
    while not height.isdigit() or height == '0':
        height = input('input height')

    while not width.isdigit() or width == '0':
        width = input('input width')

    return int(width), int(height)



def rectangle():
    twitter_tower = Rectangle()
    if np.abs(twitter_tower.get_width() - twitter_tower.get_height()) > 5:
        print(f'the rectangle area is{twitter_tower.area()}')
    else:
        print(f'the rectangle perimeter is{twitter_tower.perimeter()}')


def triangle():
    twitter_tower = Triangle()
    triangle_menu = {
        '1': twitter_tower.perimeter,
        '2': twitter_tower.print_tower
    }

    inp = input("""
                Menu:
                triangle perimeter '1'
                triangle print '2'
                """)

    while inp not in menu_dic.keys():
        inp = input('the input has written is not valid!\n make a choice again')
    try:
        triangle_menu[inp]()
    except NotValidInput as ex:
        print(ex)
    except:
        print("there is an error")


# Press the green button in the gutter to run the script.
if __name__ == '__main__':

    menu_dic = {
        '1': rectangle,
        '2': triangle,
        '3': exit
    }

    print("Hi dear user\n Wellcome to Twitter towers")

    while (True):
        inp = input("""
            Menu:
            to choose a rectangle press '1'
            to choose a triangle press '2'
            to exit press '3'
            """)

        while inp not in menu_dic.keys():
            inp = input('the input has written is not valid!\n make a choice again')
        menu_dic[inp]()
        # print('\n'.join([str(t) for t in p]) if isinstance(p, list) else p)
#
# def pythagorean(x, y):
#     c = np.sqrt(np.power(x, 2) + np.power(y, 2))
#     return c
#
#
# def perimeter(x, y, shape):
#     if shape == 3:
#         base = x
#         side1 = side2 = pythagorean(x / 2, y)
#         print(f'the perimeter is {base + side1 + side2}')
#         return base + side1 + side2
#     elif shape == 4:
#         print(f'the perimeter is {x * 2 + y * 2}')
#         return x * 2 + y * 2
#     return 0
#
#
# def area(x, y, shape):
#     if shape == 3:
#         print(f'the area is {(x * y) / 2}')
#         return (x * y) / 2
#     elif shape == 4:
#         print(f'the area is {(x * y)}')
#         return x * y
#     return 0
#
#
# def print_tower(x, y, shape):
#     if shape == 3:
#         if x % 2 == 0:
#             raise NotValidInput('cannot print the triangle')
#         elif y * 2 < x:
#             raise NotValidInput('the triangle is not valid!')
#
#         rng = range(1, x + 1, 2)
#
#         tower = [rng[0]] + np.repeat(rng[1:-1], int((y - 2) / (len(rng) - 2))).tolist() + [rng[-1]]
#
#         if (y - len(tower)) > 0:
#             [tower.insert(1, tower[1]) for _ in range(y - len(tower))]
#
#     elif shape == 4:
#         tower = [x] * y
#
#     else:
#         return
#
#     for floor in tower:
#         spaces = int((x - floor) / 2)
#         print(' ' * spaces + '*' * floor + ' ' * spaces)
