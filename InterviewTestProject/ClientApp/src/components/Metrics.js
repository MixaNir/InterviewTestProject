import React, { PureComponent } from 'react';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';

export class Metrics extends PureComponent {

    constructor(props) {
        super(props);
        this.state = { data: [], typesDropdown: [], intervalsDropdown: [], loading: true, currentTag: 1, currentInterval: 0};
    }

    componentDidMount() {
        this.getDropdownTypeInfo();
        this.getDropdownIntervalInfo();
        this.populateData(this.state.currentTag, this.state.currentInterval);
    }

    renderGraph(data) {
        return (
            <div>
                <LineChart
                    width={1300}
                    height={1000}
                    data={data}
                    margin={{
                        top: 5,
                        right: 30,
                        left: 20,
                        bottom: 5,
                    }}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="name" />
                    <YAxis />
                    <Tooltip />
                    <Legend />
                    <Line type="monotone" name="CTR" dataKey="ctr" stroke="#8884d8" activeDot={{ r: 8 }} />
                    <Line type="monotone" name="EvPM" dataKey="evPM" stroke="#82ca9d" />
                </LineChart>
            </div>
        );
    }

    renderDropdown(types, intervals) {
        const handleTypeChange = (e) => {
            this.setState({ currentTag: e.target.value, loading: true});
            this.populateData(e.target.value, this.state.currentInterval);
        }

        const handleIntervalChange = (e) => {
            this.setState({ currentInterval: e.target.value, loading: true});
            this.populateData(this.state.currentTag, e.target.value);
        }

        let loader = this.state.loading
            ? <p style={{ display: 'inline' }}><em>Loading...</em></p>
            : <p/>;

        return (
            <div class="dropdown">
                <p style={{ display: 'inline', marginRight: 10 }} >Event type: </p>

                <select id="dropdownType" onChange={(e) => handleTypeChange(e)} style={{ display: 'inline', marginRight: 100 }}>
                    {types.map((item) =>
                        <option value={item.value}>{item.name}</option>
                    )}
                </select>

                <p style={{ display: 'inline', marginRight: 10 }} >Time interval: </p>

                <select id="dropdownInterval" onChange={(e) => handleIntervalChange(e)} style={{ display: 'inline', marginRight: 100 }}>
                    {intervals.map((item) =>
                        <option value={item.value}>{item.name}</option>
                    )}
                </select>

                {loader}
            </div>
        );
    }

    render() {
        let content = this.renderGraph(this.state.data);

        let dropdowns = this.renderDropdown(this.state.typesDropdown, this.state.intervalsDropdown);

        return (
            <div>

                <h1>Graphs</h1>

                {dropdowns}

                {content}

            </div>
        );
    }

    async populateData(tag, interval) {
        const response = await fetch('/metricsvisualizer/getGraphData/' + tag + '/' + interval);
        const dataResponse = await response.json();
        this.setState({ data: dataResponse, loading: false });
    }

    async getDropdownTypeInfo() {
        const responce = await fetch('additionalInfo/getDropdownTypesInfo');
        const data = await responce.json();
        this.setState({ typesDropdown: data});
    }

    async getDropdownIntervalInfo() {
        const responce = await fetch('additionalInfo/getDropdownIntervalInfo');
        const data = await responce.json();
        this.setState({ intervalsDropdown: data});
    }
}
