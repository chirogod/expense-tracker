Es una aplicacion de consola manejada por comandos que ayudara a registrar expensas.
URL de la pagina del proyecto: https://roadmap.sh/projects/expense-tracker

# Requisitos

- Agregar una expensa indicando su descripcion, monto, mes en que se hizo, categoria a la que pertenece.
- Eliminar una expensa.
- Listar todas las expensas.
- Listar las expensas.
- Ver el resumen de expensas total.
- Ver el resumen de un mes en especifico

# Instalacion
Para usar la aplicacion, seguir los siuientes pasos:
1. Clonar el repositorio:

        git clone https://github.com/chirogod/expense-tracker.git 

2. Navegar a la raiz del proyecto

		cd expense-tracker

3. Correr los comandos deseados: (cada comando debe tener dotnet run detras.)

		dotnet run 'comandos'


##Comandos
- add --descripcion "descripcion" --amount [amount] --month [month] --category [category]: Anade una nueva expensa.
- delete --id[id]: Elimina la tarea con el id dado.
- list: Lista todas las expensas.
- summary: Resumen del total de las expensas
- summary --month [month]: Resum del total de las expensas del mes indicado.
- delete --id [id]: Elimina una expensa.

###Ejemplos
- ` dotnet run add --description "Compras en carrefour" --amount 180000 --month 2 ` // Add expensa con id 1
- ` dotnet run summary`  // Informa el total de las expensas
- ` dotnet run summary --month 2` // Informa el total de las expensas del mes 2
- ` dotnet run list`  // Lista las expensas
- ` dotnet run delete --id 1` // Elimina la expensa con id 1
