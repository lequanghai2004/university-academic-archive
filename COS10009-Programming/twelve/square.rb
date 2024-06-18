require 'gosu'

class Square < Gosu::Window
    attr_accessor :row, :column, :number, :color

    def initialize(window, column, row, color)
        @@colors ||= {
            red: Gosu::Color.argb(0xaaff0000),
            green: Gosu::Color.argb(0xaa00ff00),
            blue: Gosu::Color.argb(0xaa0000ff)
        }
        @@font ||= Gosu::Font.new(72)
        @@window ||= window
        @row = row
        @column = column
        @color = color
        @number = 1
    end

    def draw()
        if @number != 0
            x1 = 22 + @column * 100
            y1 = 22 + @row * 100
            square = 96
            c = @@colors[@color]
            @@window.draw_rect(x1, y1, square, square, c, 2)
            x_center = x1 + 48
            x_text = x_center - @@font.text_width("#{@number}")/2
            y_text = y1 + 12
            @@font.draw("#{@number}", x_text, y_text, 1)
        end
    end

end