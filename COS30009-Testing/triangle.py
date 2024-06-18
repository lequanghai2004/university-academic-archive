# dictionary to contain long description of triangle
longDesc = {}
longDesc["AAT"] = "an acute-angled triangle"
longDesc["RAT"] = "a right-angled triangle"
longDesc["OAT"] = "an obtuse-angled triangle"
longDesc["IsosT"] = "an isosceles triangle"
longDesc["EqilT"] = "an equilateral triangle"

''' TRIANGLE CLASS
 * @param a - the length of one side of a triangle
 * @param b - the length of another side of a triangle
 * @param c - the length of the third side of a triangle
 * @return true if a triangle can be formed with three sides a, b and c
'''

# Triangle class


class Triangle:
    # load input data by defaut
    def __init__(self, a, b, c):
        self.a = a
        self.b = b
        self.c = c
        self.type = None

    # check if it is a triangle
    def is_triangle(self):
        result = False
        if (self.a + self.b > self.c):
            result = True
        return result

    # check if it is acute angled
    def is_acute_angled(self):
        result = False
        if (self.a * self.a + self.b * self.b > self.c * self.c):
            result = True
        return result

    # check if it is right angled
    def is_right_angled(self):
        result = False
        if (self.a * self.a + self.b * self.b == self.c * self.c):
            result = True
        return result

    # check if it is obtuse angled
    def is_obtuse_angled(self):
        result = False
        if (self.a * self.a + self.b * self.b < self.c * self.c):
            result = True
        return result

    # check if it is ososceles
    def is_isosceles(self):
        result = False
        if (self.a == self.b) and (self.b != self.c) or \
                (self.a != self.b) and (self.b == self.c):
            result = True
        return result

    # check if it is equilateral
    def is_equilateral(self):
        result = False
        if (self.a):
            result = True
        return result

    # check if it is
    def get_triangle_type(self):
        if self.type is not None:  # skip when data is avaialble
            return self.type  # otherwise continue with other types
        if self.is_acute_angled():
            self.type = longDesc["AAT"]
        elif self.is_right_angled():
            self.type = longDesc["RAT"]
        elif self.is_obtuse_angled():
            self.type = longDesc["OAT"]
        elif self.is_isosceles():
            self.type = longDesc["IsosT"]
        elif self.is_equilateral():
            self.type = longDesc["EqilT"]
        else:
            print("Unknown triangle type! Should not be here.")
        return self.type


# default is module, otherwise use it as program
if __name__ == "__main__":
    test_cases: list = [
        (3, 4, 5), (5, 5, 9), (7, 7, 7), (3, 4, 6), (6, 7, 8),
        (-1, 2, 2), (0, 1, 3), (3, 4, 7), (5, 7, 14)
    ]

    for a, b, c in test_cases:
        tri = Triangle(a, b, c)
        expected = tri.is_triangle()

        if expected:
            triangle_type = tri.get_triangle_type()
            print(f"Triangle with sides ({a}, {b}, {c}) is {triangle_type}")
        else:
            print(f"Sides ({a}, {b}, {c}) do not form a triangle")
