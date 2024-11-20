Array.prototype.rotate = function(count) {

    for (let i = 0; i < count; i++) {
        this.push(this.shift());
    }
    return this;

}