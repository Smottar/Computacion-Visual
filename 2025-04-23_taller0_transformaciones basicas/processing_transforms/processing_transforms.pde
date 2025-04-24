void setup() {
  size(600, 400);
  ellipseMode(CENTER);
}

void draw() {
  background(255);

  float t = millis() / 1000.0;
  float amp = 100;                        // radio del movimiento circular
  float escala = 1.0 + sin(t * 2.0) * 0.5; // escala ondulada (0.5 a 1.5)
  float rotacion = t * 2.0;               // ángulo de rotación

  float x = width/2 + sin(t) * amp;
  float y = height/2 + cos(t) * amp;

  pushMatrix();
  translate(x, y);      // mueve al punto en círculo
  rotate(rotacion);     // rota como rueda
  scale(escala);        // escala ondulada
  fill(100, 150, 255);
  stroke(0);
  strokeWeight(2);
  ellipse(0, 0, 80, 80); // cuerpo de la rueda

  // Línea para visualizar el giro (como un radio)
  stroke(255, 50, 50);
  line(0, 0, 0, -40);  // radio de la rueda
  popMatrix();
}
