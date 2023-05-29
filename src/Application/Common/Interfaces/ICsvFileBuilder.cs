using Backend.Application.TodoLists.Queries.ExportTodos;

namespace Backend.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
