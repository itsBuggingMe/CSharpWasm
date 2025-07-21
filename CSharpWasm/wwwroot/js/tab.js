document.getElementById('input-text').addEventListener('keydown', function (e) {
    if (e.key != 'Tab') {
        return;
    }

    e.preventDefault();
    var start = this.selectionStart;
    var end = this.selectionEnd;
    var middleBit = this.value.substring(start, end);
    if (start == end || !middleBit.includes('\n')) {
        this.value = this.value.substring(0, start) + "    " + this.value.substring(end);
        this.selectionStart = this.selectionEnd = start + 4;
    } else {
        const lines = this.value.split('\n');
        let charCount = 0;
        let newStart = start;
        let newEnd = end;

        for (let i = 0; i < lines.length; i++) {
            const line = lines[i];
            const lineStart = charCount;
            const lineEnd = charCount + line.length;

            if (
                (lineStart >= start && lineStart <= end) ||
                (lineEnd >= start && lineEnd <= end) ||
                (lineStart <= start && lineEnd >= end)
            ) {
                if (!e.shiftKey) {
                    lines[i] = "    " + lines[i];
                    if (lineStart < start) newStart += 4;
                    newEnd += 4;
                } else {
                    if (lines[i].startsWith("    ")) {
                        lines[i] = lines[i].substring(4);
                        if (lineStart < start) newStart -= 4;
                        newEnd -= 4;
                    } else if (lines[i].startsWith("\t")) {
                        lines[i] = lines[i].substring(1);
                        if (lineStart < start) newStart -= 1;
                        newEnd -= 1;
                    }
                }
            }

            charCount += line.length + 1;
        }

        this.value = lines.join('\n');
        this.selectionStart = newStart;
        this.selectionEnd = newEnd;
    }

    this.dispatchEvent(new Event('input', { bubbles: true }));
});