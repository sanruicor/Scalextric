## Visión general / Concepto
Scalextric es un juego simple enfocado en el control de la velocidad y la inercia. Es un juego en perspectiva Top-Down (o cámara cenital) de un vehículo de juguete en una pista de carreras. El jugador controlará un pequeño coche teledirigido en una pista donde solo podrá acelerar y desacelerar, si el jugador va demasiado rápido en las curvas, el coche saldrá volando y será un Game over instantáneo.

Género: Arcade Hyper Casual
Cámara: Top down
***
## Historial de versiones
### V.0.1
Adela: Ajustes de unity, modificación de los elementos en github, asignación de tareas y gestión del repositorio.
Héctor: Redacción de los elementos "Visión General, Scope e historial de versiones".
Hugo: Redacción de los elementos "Controles, Gameplay y Asignación de tareas".
Martin: Ausente.
Daniel: Trabajo en el PMV inicial.
### V.0.2
Adela: Gestión de proyectos, manejo del repositorio de github y 
Héctor: Adición de un contador de vueltas en la interfaz que suma 1 cada vez que el coche completa una vuelta
Hugo: Implemntación de un cronometro en la interfaz
Martin/Daniel: Realizaron la pista y la movilidad del coche, así como un sprite para el coche y las salidas de game over de las curvas.
### V.0.3
Adela: Comprobación de las issues, proyectos y 
Héctor: Adición de las carreteras en la pista.
Hugo: Redacción de un nuevo Scope.
Martin/Daniel: Adición de la pantalla de Game Over.
***
## Esquema de controles
- Space: Permite acelerar y desacelerar el vehículo.
- R: Se usará para reiniciar la partida en caso de que el jugador se salga de la pista.
***
## Gameplay
El juego se basará en un circuito, el jugador usará su coche para acelerar y frenar en las curvas sin salirse de la pista. Si el jugador se sale de la pista
perderá la partida y tendrá que reiniciar la carrera.
***
## Apartado gráfico
###UI
La UI incluye un contador que lleva la cuenta de las vueltas que el coche ha dado hasta ahora, y un cronometro que cuenta el tiempo, futuramente incluirá también una pantalla de game over.
###Sprites
El coche lleva un sprite de un coche amarillo y se espera añadir un fondo y una pista para simular donde está corriendo el coche.

***
## Scope
### Scope versión 1

Se busca tener un  PMV y poco más, ni siquiera se plantea ni un sistema de puntos, ni un reloj, ni ningún tipo de mecánica compleja, solo se busca que el vehículo pueda acelerar y desacelerar, y que si acelere mucho en una curva salga volando. Se estima alcanzar el objetivo del PMV en 8 días desde hoy (14/01/26) y posterior a eso añadir assets gráficos (sprite del coche y tilemap).

Tampoco se plantea ningun tipo de elemento sonoro ni de interfaz en el juego

### Scope versión 2

El coche tiene un sprite, elementos de interfaz, y es capaz de moverse. Así como de salirse de la pista si lleva exceso de velocidad. El juego está practicamente completo al 100%, únicamente se buscaría añadir una pantalla de Game Over y un botón de restart para cuando esto ocurra; y mejorar el apartado gráfico con una pista para el coche, un fondo, y quizás modificar la tipografía de la interfaz.
***

### Scope versión 3

La pista tiene carretera y cuando el coche se pase de velocidad en ciertas curvas pasara a la tierra, es decir fuera de la pista. Cuando el jugador se salga de la pista se mostrará una pantalla de Game Over en el que el jugador tendrá que reiniciar la partida.
***
## Asignación de tareasç## Asignación de tareas
- Adela: Project Manager
- Daniel: Developer
- Martín: Lead Developer
- Héctor: Tester/QA and Documenter
- Hugo: Tester/QA and Documenter
