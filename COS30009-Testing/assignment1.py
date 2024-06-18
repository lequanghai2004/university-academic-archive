import math


def program(a: float, b: float) -> float:
    a = a - b
    c = a * 2
    return c


def test_program() -> None:
    b: float = 1.0
    a = -100.0
    tolerance = 1e-6  # You can adjust this value as needed
    while a < 100.0:
        expected = (a - b) * 2
        result = program(a, b)
        assert math.isclose(result, expected, rel_tol=tolerance, abs_tol=tolerance), \
            f"Test case failed: {result} != {expected} for a = {a}"
        a += 0.1
        print("Test case pass for a = ", a)

    print("All test cases pass")


if __name__ == "__main__":
    test_program()
