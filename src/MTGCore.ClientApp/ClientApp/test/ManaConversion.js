import Vue from 'vue'
import MyComponent from 'src/components/ManaCost.vue'

var assert = require('assert');

describe('Basic Mocha String Test', function () {
    it('should return number of charachters in a string', function () {
        assert.equal("Hello".length, 4);
    }); it('should return first charachter of the string', function () {
        assert.equal("Hello".charAt(0), 'H');
    });
});