window.textareaFunctions = {
    undoStack: [],
    addSelectListener: function (textareaId, dotnetHelper) {
        var textarea = document.getElementById(textareaId);
        textarea.addEventListener('select', function () {
            var start = textarea.selectionStart;
            var end = textarea.selectionEnd;
            var selectedText = textarea.value.substring(start, end);
            dotnetHelper.invokeMethodAsync('HandleSelect', selectedText);
        });
    },
    replaceSelectedText: function (textareaId, newText) {
        var textarea = document.getElementById(textareaId);
        var start = textarea.selectionStart;
        var end = textarea.selectionEnd;
        window.textareaFunctions.undoStack.push({ textareaId: textareaId, oldContent: textarea.value });
        textarea.setRangeText(newText, start, end);

    },
    insertText: function (textareaId, addBefore, addAfter) {
        var textarea = document.getElementById(textareaId);
        var start = textarea.selectionStart;
        var end = textarea.selectionEnd;
        window.textareaFunctions.undoStack.push({ textareaId: textareaId, oldContent: textarea.value });
        textarea.setRangeText(addBefore + textarea.value.substring(start, end) + addAfter, start, end);

        return textarea.value;
    },
    undo: function () {
        var lastAction = window.textareaFunctions.undoStack.pop();
        console.log(lastAction);

        if (lastAction) {
            var textarea = document.getElementById(lastAction.textareaId);
            return lastAction.oldContent;
        }

        return null;
    }
};