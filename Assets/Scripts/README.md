# 🏰 Escape Ratoli's Prison

Un plataformas desarrollado en Unity donde el jugador debe escapar de una peligrosa prisión llena de trampas y enfrentarse a un poderoso jefe final para conseguir la libertad.

---

## Índice

- [Descripción General](#descripción-general)
- [Controles del Jugador](#controles-del-jugador)
- [Nivel 1 — La Prisión](#nivel-1--la-prisión)
- [Nivel 2 — Combate contra el Jefe](#nivel-2--combate-contra-el-jefe)

---

## Descripción General

**Escape Ratoli's Prison** es un plataformas 3D desarrollado en Unity que pone a prueba al jugador con una gran variedad de trampas ambientales a lo largo de dos niveles. El primer nivel desafía los reflejos y las habilidades de movimiento del jugador a través de una serie de obstáculos mortales. El segundo nivel es un combate contra un jefe final en una arena dinámica dividida en cuatro biomas distintos, cada uno con mecánicas propias que alteran el movimiento y la supervivencia.

---

## Controles del Jugador

| Acción | Tecla |
|---|---|
| Moverse | `W` `A` `S` `D` |
| Saltar | `Espacio` |
| Correr (Sprint) | `Shift Izquierdo` |
| Agacharse | `Ctrl Izquierdo` |
| Correr por Paredes | Automático (correr junto a una pared) |
| Saltar desde la Pared | `Espacio` mientras se corre por la pared |

### Mecánicas de Movimiento

- **Correr por Paredes (Wall Running)** — El jugador puede desplazarse horizontalmente por las paredes al aproximarse a ellas con suficiente velocidad. El momento se mantiene durante toda la ejecución.
- **Salto desde la Pared (Wall Jumping)** — Mientras corre por una pared, el jugador puede saltar para alcanzar nuevas plataformas o continuar su desplazamiento.

**Nota:** No se puede hacer wallrun y walljump en todas las paredes.

---
## Nivel 0 - Tutorial
Este nivel actua como un tutorial para que el jugador pueda aprender nuevas mecanicas de movimiento como el wallrun y el walljump, es usa del sprint y agacharse y evitar trampas.

## Nivel 1 — La Prisión

El primer nivel es un circuito de obstáculos lineal repleto de trampas diseñadas para castigar los errores de tiempo y movimiento. A continuación se describe cada trampa:

### Péndulo con Sierras
Un gran péndulo oscila de un lado a otro bloqueando el camino del jugador, equipado con sierras giratorias. El jugador debe calcular bien el momento para cruzar y evitar ser golpeado.

### Trampas Láser
Haces de luz láser se proyectan a través de pasillos y plataformas. El contacto con un láser inflige daño o activa una penalización. Algunos láseres pueden moverse o rotar.

### Escaleras Falsas
Una escalera que parece transitable pero que se derrumba, rompe o desaparece cuando el jugador la pisa, haciéndole caer.

### Puente Colgante
Un puente de cuerda que se balancea y puede desmoronarse mientras el jugador lo cruza. Requiere movimientos cuidadosos y equilibrio para atravesarlo con éxito.

### Cañón de Troncos
Un cañón que dispara troncos horizontalmente a intervalos a través del camino del jugador. Hay que esquivarlos o sincronizar el movimiento para no ser derribado.

### Muelle / Trampolín
Un muelle o trampolín que lanza al jugador por los aires — ya sea como herramienta útil para alcanzar zonas elevadas o como trampa que lo envía hacia el peligro.

### Bombas
Dispositivos explosivos repartidos por el nivel que detonan por proximidad o tras un breve temporizador. La explosión tiene un radio de impacto que puede empujar o dañar al jugador.

### Paredes que Aparecen y Desaparecen
Paredes que alternan entre ser sólidas e intangibles siguiendo un ciclo temporizado. El jugador debe vigilar su estado para no quedar atrapado ni aplastado.

---

## Nivel 2 — Combate contra el Jefe

El segundo nivel es una arena de combate dividida en **cuatro biomas**, cada uno con sus propias mecánicas ambientales que afectan al movimiento y la supervivencia. El jefe persigue activamente al jugador durante toda la pelea, obligándole a moverse constantemente por la arena.

### El Jefe
Un enemigo que persigue sin descanso al jugador por toda la arena. El jugador debe aprovechar el entorno y sus habilidades de movimiento para esquivarlo y superarlo.

---

### 🧊 Bioma de Hielo — *Suelo Resbaladizo*

**Mecánica: Suelo Helado**
El suelo de hielo reduce la tracción, dificultando frenar o cambiar de dirección con precisión.

**Peligro Especial: Paredes Congeladoras**
Tocar las paredes de este bioma congela al jugador durante unos segundos, inmovilizándolo por completo y dejándolo expuesto al jefe.

---

### 🌋 Bioma de Lava — *Plataformas que se Destruyen*

**Mecánica: Plataformas Inestables**
Las plataformas de este bioma empiezan a desmoronarse en cuanto el jugador las pisa, destruyéndose al cabo de un segundo antes de volver a aparecer tras una breve pausa. El jugador debe mantenerse en movimiento para no caer a la lava.

---

### ⛰️ Bioma de Montaña — *Ventisca*

**Mecánica: Ventisca Persistente**
Una ventisca constante empuja al jugador lateralmente. Quedarse quieto hace que el viento arrastre al jugador en su dirección. Moverse contra el viento también se ve dificultado, obligando al jugador a luchar por cada paso.

---

### 🟤 Bioma de Barro — *Suelo Pegajoso*

**Mecánica: Velocidad de Movimiento Reducida**
El barro ralentiza considerablemente al jugador, dificultando escapar del jefe o reaccionar con rapidez.

**Peligro Especial: Molinos**
Grandes molinos giratorios están repartidos por el bioma. Al entrar en contacto con ellos, empujan al jugador y desestabilizan su movimiento, pudiendo lanzarle hacia zonas de peligro.

---
