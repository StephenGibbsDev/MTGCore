import { shallowMount } from "@vue/test-utils";
import ManaCost from "../../src/components/ManaCost.vue";
const greenImage = require("../../src/assets/images/mana-symbols/green.svg");
const blueImage = require("../../src/assets/images/mana-symbols/blue.svg");

describe("ManaCost.vue", () => {
    const manaSymbols = [
        { type: 'Green', imageName: 'green.svg' },
        { type: 'Blue', imageName: 'blue.svg' }
    ];
    const wrapper = shallowMount(ManaCost, {
        propsData: { manaSymbols }
    });

    it("renders props.manaSymbols when passed", () => {
        expect(wrapper.props("manaSymbols")).toEqual(manaSymbols);
    });

    it("renders the images correctly when passed", () => {
        const images = wrapper.findAll("img");
        expect(images.length).toBe(2);
        expect(images.at(0).attributes('src')).toEqual(greenImage);
        expect(images.at(1).attributes('src')).toEqual(blueImage);
    });
});
